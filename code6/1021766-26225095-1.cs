        protected void btnEdit_Click(object sender, EventArgs e)
        {
            DisplayDiv.Visible = false;
            EditDiv.Visible = true; 
            string SqlSelect =
                "SELECT c.CourseCode AS [Course Code], c.Description, ce.CertDate AS [Date Certified], ce.Recert, " +
                "DATEADD(m, c.Period, ce.CertDate) AS [Expiration Date], e.DocLink, e.CertifiedTrainer, e.GroupLeader " +
                "FROM Certifications c " +
                "INNER JOIN CertificationEmployees ce ON c.ID = ce.CertID " +
                "RIGHT JOIN Employees e ON ce.EmpID = e.ID " +
                "WHERE e.ID = '" + EmployeeList.SelectedValue + "' " +
                "ORDER BY [Course Code]";
            EditCertifications.SelectCommand = 
                "SELECT blahblahblabbertyblah from blah " +
                "WHERE e.ID = '" + aListImUsing.SelectedValue + "' " +
            DataView eView = (DataView)EditCertifications.Select(DataSourceSelectArguments.Empty);
            eTable = eView.ToTable();
            //use the eView table to set various onscreen values
        }
