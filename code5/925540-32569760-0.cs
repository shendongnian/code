    var local = context.Set<Contact>().Local.FirstOrDefault(c => c.ContactId == contact.ContactId);
                    if (local != null)
                    {
                        context.Entry(local).State = EntityState.Detached;
                    }
