                                    PurchaseOrder po = new PurchaseOrder();
                                    po.ReplyEmail = new EmailAddress();
                                    po.ReplyEmail.Address = "kalpana.kodavaluru@gmail.com";
                                    po.ReplyEmail.Default = false;
                                    po.ReplyEmail.DefaultSpecified = true;
                                    po.ReplyEmail.Tag = "Home";
                                    po.ShipAddr = new PhysicalAddress();
                                    po.ShipAddr.Line1 = "shippingToAddr1Sat Oct 19 09:48:52 IST 2013";
                                    po.ShipAddr.Line2 = "shippingToAddr2Sat Oct 19 09:48:52 IST 2013";
                                    po.ShipAddr.Line3 = "shippingToAddr3Sat Oct 19 09:48:52 IST 2013";
                                    po.ShipAddr.City = "Bangalore";
                                    po.ShipAddr.Country = "India";
                                    po.ShipAddr.CountrySubDivisionCode = "KA";
                                    po.ShipAddr.PostalCode = "560045";
                                    po.POEmail = new EmailAddress();
                                    po.POEmail.Address = "testing@testing.com";
                                    po.POEmail.Default = true;
                                    po.POEmail.DefaultSpecified = true;
                                    po.POEmail.Tag = "Business";
                                    po.VendorRef = new ReferenceType()
                                    {
                                        name = supplier.DisplayName,
                                        Value = supplier.Id
                                    };
                                    po.TotalAmt = new Decimal(100.00);
                                    po.TotalAmtSpecified = true;
                                    List<Line> lineList1 = new List<Line>();
                                    Line line1 = new Line();
                                    line1.Id = "1";
                                    line1.Amount = new Decimal(100.00);
                                    line1.AmountSpecified = true;
                                    line1.DetailType = LineDetailTypeEnum.ItemBasedExpenseLineDetail;
                                    line1.DetailTypeSpecified = true;
                                    ItemBasedExpenseLineDetail det = new ItemBasedExpenseLineDetail();
                                    det.ItemRef = new ReferenceType()
                                    {
                                        name = item.Name,
                                        Value = item.Id
                                    };
                                   
                                    det.Qty = new decimal(1);
                                    det.QtySpecified = true;
                                   
                                    det.ItemElementName = ItemChoiceType.UnitPrice;
                                    det.AnyIntuitObject = new decimal(100);
                                    det.BillableStatus = new BillableStatusEnum();
                                    line1.AnyIntuitObject = det;
                                    lineList1.Add(line1);
                                    po.Line = lineList1.ToArray();
                                    try
                                    {
                                        var podata=commonService.Add(po);
                                    }
                                    catch (Exception ex)
                                    {
                                        throw ex;
                                    }
