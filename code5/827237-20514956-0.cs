     public void ExportIniEmployeeToExcel(EligibilityCriteriaModel AllIniEmp)
        {
            List<AllIniEmployees> emp = new List<AllIniEmployees>();            
            AllIniEmp.allSuccessEmployeeList.ForEach(x =>
                {
                    AllIniEmployees allEmp = new AllIniEmployees();
                    allEmp.EmployeeCode = x.EmployeeCode;
                    allEmp.EmployeeName = x.EmployeeName;
                    allEmp.Designation = x.Designation;
                    allEmp.DeliveryTeam = x.DeliveryTeam;
                    allEmp.ConfirmationDate = x.ConfirmationDate;
                    emp.Add(allEmp);
                });
            GridView gv = new GridView();
            gv.DataSource = emp;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=InitiatedEmployees.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
