    foreach (var item in obj)
                        {
                            RMCustomer customer = new RMCustomer();
                            if (item.ID != null && item.ID.Length > 0)
                            {
                                customer.RMInternalUniqueID = Convert.ToInt32(item.ID);
                            }
                            if (item.Code != null && item.Code.Length > 0)
                            {
                                customer.CustomerRMExternalID = Convert.ToInt32(item.Code);
                            }
                            else
                            {
                                customer.CustomerRMExternalID = null;
                            }
                            if (item.Name != null && item.Name.Length > 0)
                            {
                                customer.CustomerName = item.Name;
                            }
                            if (customer != null)
                            {
                                roadMarqueCustomers.Add(customer);
                            }
                        }
