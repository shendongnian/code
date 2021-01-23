    from st in dbContext.Students where st.DepartmentID == 17
                 join d in dbContext.Departments on st.DepartmentID equals d.DepartmentID
                 join sv in dbContext.SoftwareVersions on st.SoftwareVersionID equals sv.SoftwareVersionID
                 join stat in dbContext.Statuses on st.StatusID equals stat.StatusID
                 join m in dbContext.Marks on st.MarkID equals m.MarkID
                 select new
                 {
                     student = st.StudentName,
                     department = p.DepartmentName,
                     software = sv.SoftwareVersionName,
                     status = st.StatusName,
                     marked = m != null ? m.MarkName : "-- Not marked --"
                 };
