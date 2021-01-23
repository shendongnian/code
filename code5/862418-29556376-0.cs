    public class Person
        {
            /// <summary>
            /// USAGE: await UpdateDbEntryAsync(myPerson, d => d.FirstName, d => d.LastName);
            /// </summary>
            async Task<bool> UpdateDbEntryAsync<T>(T entity, params Expression<Func<T, object>>[] properties) where T : class
            {
                try
                {
                    var db = new RtTradeData.Models.ApplicationDbContext();
                    var entry = db.Entry(entity);
                    db.Set<T>().Attach(entity);
                    foreach (var property in properties)
                        entry.Property(property).IsModified = true;
                    await db.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("UpdateDbEntryAsync exception: " + ex.Message);
                    return false;
                }
            }
            
            /// <summary>
            /// The idea is that SomeFunction already has the instance of myPerson, that it wants to update.
            /// </summary>
            public void SomeFunction()
            {
                myPerson.FirstName = "Another Name"; myPerson.LastName = "NewLastName";
                UpdateDbEntryAsync(myPerson, d => d.FirstName, d => d.LastName);
            }
            /// <summary>
            /// Or directly requesting the person instance to update its own First and Last name...
            /// </summary>
            public void Update(string firstName, string lastName)
            {
                FirstName = "Another Name"; LastName = "NewLastName";
                UpdateDbEntryAsync(this, d => d.FirstName, d => d.LastName);
            }
            Person myPerson = new Person { PersonId = 5, FirstName = "Name", LastName = "Family" };
            public int PersonId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
