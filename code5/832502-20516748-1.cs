     var zz= context.ControlPolicy.Create().GetType().GetProperty("MemberState").GetValue(cp1);
 
     context.Entry(dmm.Set<ControlPolicy>().Find(entityKey)).CurrentValues.SetValues(cp1);
     context.SaveChanges();
                   
