    foreach (var item in request.Filters)
                    {
                        if (item is Kendo.Mvc.CompositeFilterDescriptor)
                        {
                            var result = Gatherfileds((Kendo.Mvc.CompositeFilterDescriptor) item);
                            foreach (var filterDescriptor in result)
                            {
                                listoffilters.Add(filterDescriptor);
                            }
                        }
                        if (item is Kendo.Mvc.FilterDescriptor)
                        {
                            var descriptor = (Kendo.Mvc.FilterDescriptor)item;
                            listoffilters.Add(descriptor);
                        }
                    }
