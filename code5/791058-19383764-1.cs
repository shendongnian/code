	for (int i = oViewCollection.Count - 1; i >= 0; --i)
	{
		SPView oViewColl = oViewCollection[i];
		if (oViewColl.Title == "MyCustomView")
		{
			oViewCollection.Delete(oViewColl.ID);
		}
	}
