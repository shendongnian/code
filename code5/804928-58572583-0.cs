    DataBonzClinicDataContext db = new DataBonzClinicDataContext();
                var tsel = (from u in db.tblsysusers 
                           where (u.pass_id==cbxUser.Text.ToString().Trim()) 
                          select u.pass_imgid).First();            
                if (tsel != null)
                {
                   var imgdata = tsel.ToArray();
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imgdata);
                    pictureBox1.Image = Image.FromStream(ms);
                }
