    string xml = @"<?xml version=""1.0"" encoding=""utf-8""?>
    <Cameras>
      <Camera>
        <Model>Canon EOS-1D</Model>
        <Price>$5219</Price>
      </Camera>
      <Camera>
        <Model>Canon EOS-1D Mark IV</Model>
        <Price>$5000</Price>
      </Camera>
    </Cameras>";
    StringReader sr = new StringReader(xml); // Step 1
    DataSet ds = new DataSet();
    ds.ReadXml(sr); // Step 2
    GridView1.DataSource = ds.Tables[0]; // Step 3
    GridView1.DataBind();
