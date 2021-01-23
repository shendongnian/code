        public async void btnGet_Tap()
        {
            await Foo();
        }
        public async Task Foo()
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            try
            {
                // Getting JSON from file if it exists, or file not found exception if it does not
                StorageFile textFile = await localFolder.GetFileAsync("breakfastList.json");
                using (IRandomAccessStream textStream = await textFile.OpenReadAsync())
                {
                    // Read text stream 
                    using (DataReader textReader = new DataReader(textStream))
                    {
                        //get size
                        uint textLength = (uint)textStream.Size;
                        await textReader.LoadAsync(textLength);
                        // read it
                        string jsonContents = textReader.ReadString(textLength);
                        // deserialize back to our products!
                        //I only had to change this following line in this function
                        breakfastRecipe = JsonConvert.DeserializeObject<IList<Recipe>>(jsonContents) as List<Recipe>;
                        // and show it
                        //displayProduct();
                    }
                }
            }
            catch (Exception ex)
            {
                tester.Text = "error";
            }
        }
 
