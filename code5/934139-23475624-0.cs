    var eventsList = (from c in _categoryRepository.Table
                      orderby c.Name
                      select new MyActiveEvents { Id = c.Id, Name = c.Name })
                     .Except(
                    from c in _categoryRepository.Table
                    join m in _MemberEventRepository.Table on c.Id equals m.EventID
                    where (m.MemID == currentCustomer)         
                    select new MyActiveEvents { Id = c.Id, Name = c.Name });
