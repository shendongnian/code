    public static void LoadFile(byte[] bytes)
    {
        ClearAll();
        using(Stream file = File.Open(fileName, FileMode.Open))
        {
            BinaryFormatter bf = new BinaryFormatter();
            object obj = bf.Deserialize(file);
            var objects  = obj as List<object>;
            //you may want to run some checks (objects is not null and contains 2 elements for example)
			var nodes = objects[0] as List<TreeNode>;
			var dictionary = objects[1] as Dictionary<int, Tuple<List<string>,List<string>>>;
 			
            //use nodes and dictionary
        }
    }
