            List<Project> lst = new List<Project>();
            for (int i = 0; i < lst1.Count; i++)
            {
                double cusnum = 0;
                var lst2q = (from s in lst2
                                where s.ProjectId == lst1[i].ProjectId
                                select s).ToArray();
                if (lst2q.Length > 0)
                {
                    cusnum = lst2q[0].CustomerNum;
                }
                
              
                var lst3q = (from s in lst3
                             where s.ProjectId == lst1[i].ProjectId
                             select s).ToArray();
                double cusadd = 0;
                if (lst3q.Length > 0)
                {
                    cusadd = lst3q[0].Address;
                }
                lst.Add(new Project
                    {
                        ProjectId = lst1[i].ProjectId,
                        ProjectName = lst1[i].ProjectName,
                        CustomerNum = cusnum,
                        Address = cusadd,
                    });
            }
