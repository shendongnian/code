    public void ReadData()
    {
        // Opens the Data.txt file for read access
        FileStream mediaFile = new FileStream("Data.txt", FileMode.Open, FileAccess.Read);
        StreamReader mediaData = new StreamReader(mediaFile);
        string mediaRow; // Holds each media data per row
        Media media = null;
        var list = new List<Media>();
        while ((mediaRow = mediaData.ReadLine()) != null)
        {
            if (mediaRow.startsWith("-----") && media != null) {
                list.add(media);
                media = null;
            }
            else 
            {
                if (media != null) media.parseDescription(mediaRow);
                else {
                    string[] mediaDataSplit = mediaRow.Split('|');
                    media = constructMediaOfType(mediaDataSplit[0]);
                    media.parseMediaInfo(mediaDataSplit);        
                }               
            }           
        }
    }
    private static Media constructMediaOfType(String type) 
    {
        switch (type) {
            case "BOOK": return new Book();
            case "SONG": return new Song();
            case "MOVIE" return new Movie();
            default: throw new NotImplementedException();
        }
    }
        
