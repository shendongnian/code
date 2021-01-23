    List<NewsletterContactEmails> Recipients = objNewsletter.NewsletterToLists
        .SelectMany(ntl => ntl.NewsletterList.NewsletterListToContacts
            .Where(nl => nl.Active == true && nl.Deleted == false && nl.UnsubscribedOn == null)
            .Select(nl => new NewsletterContactEmails
            {
                ContactID = nl.ContactID,
                EmailList =
                    nl.Contact.ContactEmails.Where(ce => ce.Deleted == false)
                        .Select(ce => ce.EmailAddress)
                        .Distinct()
                        .ToList()
            }));
