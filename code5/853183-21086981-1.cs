    IMobileServiceTableQuery<todoTable> query = todoTable.Where(t => t.fname == "[Your Name]");
                var res = await query.ToListAsync();
                var item = res.First();
                //fName is a string in your object MyTable just get it like this
                string fname = item.fname;
