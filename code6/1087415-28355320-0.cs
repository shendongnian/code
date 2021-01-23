         private static async void AsyncGetAllTypesInContainer<t>(BrowserWindow bw, Action<List<t>> Callback)
        {
            var list = new List<t>();
            await Task.Factory.StartNew(() =>
            {
                list = bw.GetChildren().OfType<t>().ToList();
            });
            Callback(list);
        }
    }
