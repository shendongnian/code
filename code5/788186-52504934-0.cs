                         if (days >= 180 || inStock == false)
                        {
                            if (mainGetSet.OrderID != MainGetSet.EMAILCANCELO)
                            {
                                if (debugging == true)
                                {
                                    MessageBox.Show("Here is where support will get an email instead of it being canceled. Order ID: " + mainGetSet.OrderID);
                                }
                                string subject = "Please check order " + mainGetSet.OrderID + " to ascertain if possible cancel action is needed.";
                                string body = "Dear Support \r\n \r\nPlease check order " + mainGetSet.OrderID + " to confirm if a possible cancel action is needed " +
                                "and please process manually. Here is the SKU " + childGetSet.Sku + ". Thank you. " +
                                " \r\n \r\n Kind Regards, \r\n IT Department";
                                sendEmail.SendEmailToSupport(subject, body);
                                // Database call to the cancel order DB
                                CanceledDB.AddJSONInfo(childGetSet);
                                //readyResponse = CancelKiboOrder.MakeOrderCanceled(token, mainGetSet.OrderID);
                            }
                            MainGetSet.EMAILCANCELO = mainGetSet.OrderID;
                        }
                        else
                        {
                            if (debugging == true)
                            {
                                MessageBox.Show("Here is where support will get an email about the backorder date. Order ID: " + mainGetSet.OrderID);
                            }
                            //DateTime backorder180 = new DateTime().AddDays(days);
                            //string backOrder = backorder180.ToString("yyyy-MM-dd'T'HH:mm:ss");
                            string backOrder = DateTime.UtcNow.AddDays(days).ToString("s") + "Z";
                            string ItemsQty = string.Empty;
                            for (int iq = 0; iq < jsonGetSet.OrderItemID.Count; iq++)
                            {
                                //ItemsQty += "{  \r\n        \"autoAssign\":false,\r\n        \"locationID\":169309,\r\n        \"shipmentStatus\":\"READY\",\r\n        \"itemAssign\":[  \r\n           {  \r\n              \"orderItemID\":" + jsonGetSet.OrderItemID[iq] + ",\r\n              \"quantity\":" + jsonGetSet.Quantity[iq] + "\r\n           }\r\n        ]\r\n     }\r\n";
                                ItemsQty += "    {\r\n         \"shipmentStatus\":\"BACKORDER\",\r\n         \"backOrderReleaseDate\":\"" + backOrder + "\",\r\n         \"itemAssign\":[\r\n            {\r\n               \"orderItemID\":" + jsonGetSet.OrderItemID[iq] + ",\r\n               \"quantity\":" + jsonGetSet.Quantity[iq] + "\r\n            }\r\n         ]\r\n      }\r\n ";
                                if (jsonGetSet.OrderItemID.Count > 0 && iq < jsonGetSet.OrderItemID.Count - 1)
                                {
                                    ItemsQty += ",";
                                }
                            }
                            if (debugging == true)
                            {
                                MessageBox.Show(ItemsQty);
                            }
                            string subject = "Please check backorder number " + mainGetSet.OrderID + " to ascertain  the reason.";
                            string body = "Dear Support \r\n \r\nPlease check backorder number " + mainGetSet.OrderID + " to confirm  the backorder. " +
                                "Here is the SKU " + childGetSet.Sku + "."+
                                " \r\n \r\n Kind Regards, \r\n IT Department";
                            sendEmail.SendEmailToSupport(subject, body);
                            readyResponse = Backorder.MakeOrderBackorder(token, mainGetSet.OrderID, ItemsQty);
                        }
                        if (debugging == true)
                        {
                            DebugOutput(readyResponse, textBox);
                        }
                        var parsedReady = new JObject();
                        try
                        {
                            parsedReady = JObject.Parse(readyResponse);
                        }
                        catch (Exception JEx)
                        {
                            if (debugging == true)
                            {
                                MessageBox.Show("The program threw an Exception: " + JEx);
                            }
                            else
                            { 
                                string messageSubject = "There was a problem with the JSON for the BackOrder in KIBO.";
                                string messageBody = "There was a problem with the JSON for the BackOrder in KIBO. Error: " +
                                    "\r\n \r\n \r\n Here is the JSON returned: " + parsedReady;
                                string kiboSendEmail = string.Empty;
                                kiboSendEmail = sendEmail.SendEmailCS(messageSubject, messageBody, JEx);
                                if (mainGetSet.OrderID != MainGetSet.EMAILCANCELO)
                                {
                                    if (debugging == true)
                                    {
                                        MessageBox.Show("Here is where support will get an email instead of it being canceled. Order ID: " + mainGetSet.OrderID);
                                    }
                                    string subject = "Please check order " + mainGetSet.OrderID + " to ascertain if possible cancel action is needed.";
                                    string body = "Dear Support \r\n \r\nPlease check order " + mainGetSet.OrderID + " to confirm if a possible cancel action is needed " +
                                    "and please process manually. Here is the SKU " + childGetSet.Sku + ". Thank you. " +
                                    " \r\n \r\n Kind Regards, \r\n IT Department";
                                    sendEmail.SendEmailToSupport(subject, body);
                                    // Database call to the cancel order DB
                                    CanceledDB.AddJSONInfo(childGetSet);
                                    //readyResponse = CancelKiboOrder.MakeOrderCanceled(token, mainGetSet.OrderID);
                                }
                                MainGetSet.EMAILCANCELO = mainGetSet.OrderID;
                          
                                {
                                if (debugging == true)
                                {
                                    MessageBox.Show("Here is where support will get an email about the backorder date. Order ID: " + mainGetSet.OrderID);
                                }
                                //DateTime backorder180 = new DateTime().AddDays(days);
                                //string backOrder = backorder180.ToString("yyyy-MM-dd'T'HH:mm:ss");
                                string backOrder = DateTime.UtcNow.AddDays(days).ToString("s") + "Z";
                                string ItemsQty = string.Empty;
                                for (int iq = 0; iq < jsonGetSet.OrderItemID.Count; iq++)
                                {
                                    //ItemsQty += "{  \r\n        \"autoAssign\":false,\r\n        \"locationID\":169309,\r\n        \"shipmentStatus\":\"READY\",\r\n        \"itemAssign\":[  \r\n           {  \r\n              \"orderItemID\":" + jsonGetSet.OrderItemID[iq] + ",\r\n              \"quantity\":" + jsonGetSet.Quantity[iq] + "\r\n           }\r\n        ]\r\n     }\r\n";
                                    ItemsQty += "    {\r\n         \"shipmentStatus\":\"BACKORDER\",\r\n         \"backOrderReleaseDate\":\"" + backOrder + "\",\r\n         \"itemAssign\":[\r\n            {\r\n               \"orderItemID\":" + jsonGetSet.OrderItemID[iq] + ",\r\n               \"quantity\":" + jsonGetSet.Quantity[iq] + "\r\n            }\r\n         ]\r\n      }\r\n ";
                                    if (jsonGetSet.OrderItemID.Count > 0 && iq < jsonGetSet.OrderItemID.Count - 1)
                                    {
                                        ItemsQty += ",";
                                    }
                                }
                                if (debugging == true)
                                {
                                    MessageBox.Show(ItemsQty);
                                }
                                string subject = "Please check backorder number " + mainGetSet.OrderID + " to ascertain  the reason.";
                                string body = "Dear Support \r\n \r\nPlease check backorder number " + mainGetSet.OrderID + " to confirm  the backorder. " +
                                    "Here is the SKU " + childGetSet.Sku + "." +
                                    " \r\n \r\n Kind Regards, \r\n IT Department";
                                sendEmail.SendEmailToSupport(subject, body);
                                readyResponse = Backorder.MakeOrderBackorder(token, mainGetSet.OrderID, ItemsQty);
                            }
                            if (debugging == true)
                            {
                                DebugOutput(readyResponse, textBox);
                            }
                            parsedReady = new JObject();
                            try
                            {
                                parsedReady = JObject.Parse(readyResponse);
                            }
                            catch (Exception Jx)
                            {
                                if (debugging == true)
                                {
                                    MessageBox.Show("The program threw an Exception: " + Jx);
                                }
                                else
                                {
                                    messageSubject = "There was a problem with the JSON for the BackOrder in KIBO.";
                                    messageBody = "There was a problem with the JSON for the BackOrder in KIBO. Error: " +
                                        "\r\n \r\n \r\n Here is the JSON returned: " + parsedReady;
                                    kiboSendEmail = string.Empty;
                                    kiboSendEmail = sendEmail.SendEmailCS(messageSubject, messageBody, JEx);
                                }
                            }
