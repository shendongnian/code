        private void SaveProcSurg()
        {
            using (MCASURGContext db2 = new MCASURGContext())
            {
                //Get Record from DB
                scar_Requests sReq = db2.scar_Requests.Include("scar_Users").Include("scar_Status").Include("scar_Procedures.scar_Surgeons").Where(x => x.RequestID == ReqID).FirstOrDefault();
                //Update Record fields
                sReq.CreationDate = req.CreationDate == null ? DateTime.Now : req.CreationDate = req.CreationDate;
                sReq.DateOfSurgery = dtpDateOfSurgery.Value;
                sReq.IsDeleted = false;
                sReq.IsScheduled = false;
                sReq.LatexAllergy = cbLatexAllergy.Checked;
                sReq.ModifiedDate = DateTime.Now;
                sReq.MRN = txtMRN.Text;
                sReq.PatientName = txtPatientName.Text;
                foreach (RadioButton rb in gbPatientType.Controls) if (rb.Checked == true) sReq.PatientType = rb.Text;
                sReq.PreOpDiagnosis = txtPreOpDiag.Text;
                sReq.PrimarySurgeon = txtPrimarySurgeon.Text;
                sReq.PrivateComment = txtPrivateComment.Text;
                sReq.PublicComment = txtPublicComment.Text;
                sReq.RequestID = ReqID;
                sReq.StatusID = req.StatusID;
                sReq.UserID = req.UserID;
                //Update Users/Status
                sReq.scar_Users = db2.scar_Users.Where(x => x.UserID == sReq.UserID).FirstOrDefault();
                sReq.scar_Status = db2.scar_Status.Where(x => x.StatusID == req.StatusID).FirstOrDefault();
                //Attach to DBContext
                db2.scar_Requests.Attach(sReq);
                //Update Procedures
                foreach (Procedure p in AddProcedures)
                {
                    scar_Procedures pro = sReq.scar_Procedures.Where(x => x.ProcedureID == p.Proc.ProcedureID && p.Proc.ProcedureID != 0).FirstOrDefault();
                    if (pro != null)
                    {
                        pro.EnRecovery = p.Proc.EnRecovery;
                        pro.IsPrimary = p.Proc.IsPrimary;
                        pro.Laterality = p.Proc.Laterality;
                        pro.OrthoFastTrack = p.Proc.OrthoFastTrack;
                        pro.ProcedureID = p.Proc.ProcedureID;
                        pro.ProcedureText = p.Proc.ProcedureText;
                        pro.RequestID = ReqID;
                        pro.Site = p.Proc.Site;
                    }
                    else
                    {
                        pro = new scar_Procedures();
                        pro.EnRecovery = p.Proc.EnRecovery;
                        pro.IsPrimary = p.Proc.IsPrimary;
                        pro.Laterality = p.Proc.Laterality;
                        pro.OrthoFastTrack = p.Proc.OrthoFastTrack;
                        pro.ProcedureID = p.Proc.ProcedureID;
                        pro.ProcedureText = p.Proc.ProcedureText;
                        pro.RequestID = ReqID;
                        pro.Site = p.Proc.Site; ;
                        pro.scar_Requests = sReq;
                    }
                    //Update Surgeons
                    pro.scar_Surgeons.Clear();
                    foreach (scar_Surgeons s in p.Surgeons)
                    {
                        pro.scar_Surgeons.Add(db2.scar_Surgeons.Where(x=> x.SurgeonID == s.SurgeonID).FirstOrDefault());
                    }
                }
                //Set State and Save
                db2.Entry(sReq).State = System.Data.Entity.EntityState.Modified;
                db2.SaveChanges();
            }
        }
