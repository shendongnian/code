        public JsonResult GetProductsData()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5136/api/");
                //HTTP GET
                var responseTask = client.GetAsync("product");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<product>>();
                    readTask.Wait();
                    var alldata = readTask.Result;
                    var rsproduct = from x in alldata
                                 select new[]
                                 {
                                 Convert.ToString(x.pid),
                                 Convert.ToString(x.pname),
                                 Convert.ToString(x.pprice),
                          };
                    return Json(new
                    {
                        aaData = rsproduct
                    },
        JsonRequestBehavior.AllowGet);
                }
                else //web api sent error response 
                {
                    //log response status here..
                   var pro = Enumerable.Empty<product>();
                    return Json(new
                    {
                        aaData = pro
                    },
        JsonRequestBehavior.AllowGet);
             
                }
            }
        }
        public JsonResult InupProduct(string id,string pname, string pprice)
        {
            try
            {
                product obj = new product
                {
                    pid = Convert.ToInt32(id),
                    pname = pname,
                    pprice = Convert.ToDecimal(pprice)
                };
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5136/api/product");
                    if(id=="0")
                    {
                        //insert........
                        //HTTP POST
                        var postTask = client.PostAsJsonAsync<product>("product", obj);
                        postTask.Wait();
                        var result = postTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            return Json(1, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(0, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        //update........
                        //HTTP POST
                        var postTask = client.PutAsJsonAsync<product>("product", obj);
                        postTask.Wait();
                        var result = postTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            return Json(1, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(0, JsonRequestBehavior.AllowGet);
                        }
                    }
               
                   
                }
                /*context.InUPProduct(Convert.ToInt32(id),pname,Convert.ToDecimal(pprice));
                return Json(1, JsonRequestBehavior.AllowGet);*/
            }
            catch (Exception ex)
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult deleteRecord(int ID)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5136/api/product");
                    //HTTP DELETE
                    var deleteTask = client.DeleteAsync("product/" + ID);
                    deleteTask.Wait();
                    var result = deleteTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return Json(1, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(0, JsonRequestBehavior.AllowGet);
                    }
                }
               /* var data = context.products.Where(x => x.pid == ID).FirstOrDefault();
                context.products.Remove(data);
                context.SaveChanges();
                return Json(1, JsonRequestBehavior.AllowGet);*/
            }
            catch (Exception ex)
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
