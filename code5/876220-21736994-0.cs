       public static Collection<ItemId> BatchCreateCalendarItems(ExchangeService service)
        {
            // These are unsaved local instances of an Appointment object.
            // Despite the required parameter of an ExchangeService object (service), no call
            // to an Exchange server is made when the objects are instantiated.
            // A call to the Exchange server is made when the service.CreateItems() method is called.
            Appointment appt1 = new Appointment(service);
            Appointment appt2 = new Appointment(service);
            Appointment appt3 = new Appointment(service);
            Appointment appt4 = new Appointment(service);
            // Set the properties for a single instance appointment
            appt1.Subject = "Appt1";
            appt1.Body = "Appt1";
            appt1.Start = DateTime.Now.AddDays(1);
            appt1.End = appt1.Start.AddHours(3);
            appt1.Location = "My office";
            appt1.ReminderMinutesBeforeStart = 30;
            // Set the properties for a single instance appointment
            appt2.Subject = "Appt2";
            appt2.Body = "Appt2";
            appt2.Start = DateTime.Now.AddDays(1);
            appt2.End = appt1.Start.AddHours(4);
            appt2.Location = "My office";
            appt2.ReminderMinutesBeforeStart = 30;
           
            // Set the properties for a single instance appointment
            appt3.Subject = "Appt3";
            appt3.Body = "Appt3";
            appt3.Start = DateTime.Now.AddDays(1);
            appt3.End = appt1.Start.AddHours(5);
            appt3.Location = "My office";
            appt3.ReminderMinutesBeforeStart = 30;
            
            // Set the properties for a single instance appointment
            appt4.Subject = "Appt4";
            appt4.Body = "Appt4";
            appt4.Start = DateTime.Now.AddDays(1);
            appt4.End = appt1.Start.AddHours(6);
            appt4.Location = "My office";
            appt4.ReminderMinutesBeforeStart = 30;
            // Add the appointment objects to a collection
            Collection<Appointment> calendarItems = new Collection<Appointment>() { appt1, appt2, appt3, appt4 };
            // Instantiate a collection of item ids to populate from the values that are returned by the Exchange server.
            Collection<ItemId> itemIds = new Collection<ItemId>();
            // Send the batch of appointment objects.
            // Note that multiple calls to the Exchange server may be made when appointment objects have attachments.
            // Note also that the item collection passed as the first parameter to CreateItems will have their ids set on return.
            ServiceResponseCollection<ServiceResponse> response = service.CreateItems(calendarItems,
                                                                                      WellKnownFolderName.Calendar,
                                                                                      MessageDisposition.SendAndSaveCopy,
                                                                                      SendInvitationsMode.SendToAllAndSaveCopy);
            if (response.OverallResult == ServiceResult.Success)
            {
                Console.WriteLine("All appointments and meetings sucessfully created.");
            }
            // Collect the item ids from the created calendar items.
            foreach (Appointment appt in calendarItems)
            {
                itemIds.Add(appt.Id);
            }
            int counter = 1;
            // Show the ids and errors for each message
            foreach (ServiceResponse resp in response)
            {
                // Note that since item ids are long, show only 5 characters.
                Console.WriteLine("Result (message {0}), id {1}: {2}", counter, itemIds[counter - 1].ToString().Substring(0, 5), resp.Result);
                Console.WriteLine("Error Code: {0}", resp.ErrorCode);
                Console.WriteLine("ErrorMessage: {0}\r\n", resp.ErrorMessage);
                counter++;
            }
            // Return the collection of item ids
            return itemIds;
        }
