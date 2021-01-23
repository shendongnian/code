     var ids = new List<Guid>();
                foreach (var id in ids)
                {
                    Employee employee = new Employee();
                    employee.Id = id;
                    entityEntry = context.Entry(employee);
                    entityEntry.State = EntityState.Deleted;
                }
                context.SaveChanges();
