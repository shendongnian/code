    #region Person
            /// <summary>
            /// List all of the people in the specified collection
            /// documentation:  https://developers.google.com/+/api/latest/people/list
            /// </summary>
            /// <param name="service"></param>
            /// <param name="_userId">Get the collection of people for the person identified. Use "me" to indicate the authenticated user.</param>
            /// <returns></returns>
            public static IList<Person> GetAllPeople(PlusService service, string _userId)
            {
                PeopleResource.ListRequest list = service.People.List(_userId, PeopleResource.ListRequest.CollectionEnum.Visible);
                list.MaxResults = 10;
                PeopleFeed peopleFeed = list.Execute();
                IList<Person> people = new List<Person>(); 
    
                //// Loop through until we arrive at an empty page
                while (peopleFeed.Items != null)
                {
                    // Adding each item  to the list.
                    foreach (Person item in peopleFeed.Items)
                    {
                        people.Add(item);
                    }
    
                    // We will know we are on the last page when the next page token is
                    // null.
                    // If this is the case, break.
                    if (peopleFeed.NextPageToken == null)
                    {
                        break;
                    }
    
                    // Prepare the next page of results
                    list.PageToken = peopleFeed.NextPageToken;
    
                    // Execute and process the next page request
                    peopleFeed = list.Execute();
                    
                }
    
                return people;
    
            }
