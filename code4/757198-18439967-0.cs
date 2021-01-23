    // Saving in session
                System.Collections.Hashtable ht = new System.Collections.Hashtable();
                ht.Add("EmployeeName", "EmpName Value");
                ht.Add("Designation", "Designation Value");
                ht.Add("Department", "Department Value");
                Session["EmployeeInfo"] = ht;
                //Retrieve from session
                if (Session["EmployeeInfo"] != null)
                {
                    string strEmployeeName = ht.ContainsKey("EmployeeName") ? Convert.ToString(ht["EmployeeName"]) : "";
                    string strDesignation = ht.ContainsKey("Designation") ? Convert.ToString(ht["Designation"]) : "";
                    string strDepartment = ht.ContainsKey("Department") ? Convert.ToString(ht["Department"]) : "";
                }
