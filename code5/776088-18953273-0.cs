         private void LoadDeliveryData()
            {
                RST_DBDataContext conn = new RST_DBDataContext();
                var BikesOrderData = conn.TblBikesOrdersDetails
                    .Where(TblBikesOrdersDetail => TblBikesOrdersDetail.BOId == 1)
                                .Select(TblBikesOrdersDetail => new
                                {
                                    qty = TblBikesOrdersDetail.BQty,
                                    ModelID = TblBikesOrdersDetail.ModelId,
                                    ModelName = TblBikesOrdersDetail.TblBikeModel.ModelName
                                });
                List<BikesOrderObjects> data = new List<BikesOrderObjects>();
                foreach (var item in BikesOrderData)
                {
                    
                    for (int i = 0; i < item.qty; i++)
                    {
                        BikesOrderObjects datae = new BikesOrderObjects();
                        datae.ModelName = item.ModelName;
                        data.Add(datae);
                    }
                    
                }
    
                DeliveryGrid.ItemsSource = data;
    
            }
