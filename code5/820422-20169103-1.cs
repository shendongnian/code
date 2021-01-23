	public List<Photos> LoadImages ///List Retrieves and Loads Photos
	{
		get
		{
			List<Photos> images = new List<Photos>();
			if (HDDSelectionBox.SelectedItem != null)
			{
				string path = HDDSelectionBox.SelectedItem.ToString(); //ComboBox SelectedItem Converted To String As Path
				foreach (string filename in Directory.GetFiles(path, "*.jpg"))
				{
					try
					{
						images.Add( //Add To List
							new Photos(
								new BitmapImage(
									new Uri(filename)),
									System.IO.Path.GetFileNameWithoutExtension(filename)));
					}
					catch { } //Skips Any Image That Isn't Image/Cant Be Loaded
				}
			}
			return images;
		}
	}
