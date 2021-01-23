            List<Employee2> employee2 = new List<Employee2>
            {
                new Employee2 { EmpId = 1, EmpName = "Bob" },
                new Employee2 { EmpId = 2, EmpName = "Sam" },
                new Employee2 { EmpId = 3, EmpName = "Jim" },
            };
            List<Attendance> attandance = new List<Attendance>
            {
                new Attendance { EmpId = 1 },
                new Attendance { EmpId = 2 },
                new Attendance { EmpId = 2 },
                new Attendance { EmpId = 3 },
                new Attendance { EmpId = 3 },
                new Attendance { EmpId = 3 },
            };
            var r = from emp in employee2
                    join att in attandance on emp.EmpId equals att.EmpId
                    group emp by emp.EmpName into g
                    select new { EmpName = g.Key, Count = g.Count() };
