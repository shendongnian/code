                foreach (var booking in doc.Descendants("Booking"))
                {
                    var customer = booking.Element("Customer");
                    var holiday = booking.Element("Holiday");
                    var travelInfo = booking.Element("TravelInfo");
                    XElement element;
                    if (customer != null)
                    {
                        if ((element = customer.Element("CustomerId")) != null)
                            txtCustomerId.Text = txtCustomerId.Text + element.Value;
                    }
                    // And so on.
                }
