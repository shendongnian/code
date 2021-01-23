    void GetImage(int imageId) {
        byte[] imageData = GetDataFromDatabase(imageId);
        using (MemoryStream ms = new MemoryStream(imageData)) {
            Response.ContentType = "image/png";
            ms.WriteTo(Response.OutputStream);
        }
    }
