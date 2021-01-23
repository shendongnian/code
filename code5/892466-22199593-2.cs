    boko_data_json itemsToRemove = new boko_data_json();
    
    foreach (var item in ListAvailableData.data)
                {
                    string PDFPath = item.downloadpdfpath;
                    string filename = lastPart.Split('.')[0];
                    int result = obj.getfile(filename);
                    if (result == 1)
                    {
                        itemsToRemove.data.Add(item);
                    }
                }
    
    foreach (var itemToRemove in itemsToRemove)
    {
         ListAvailableData.data.Remove(itemToRemove);
    }
