    public void GetThumbnail(string video, string jpg, string velicina)
    {
        if (velicina == null) velicina = "640x480";
        exec(video, "-ss 00:00:06 -s" + velicina, jpg);
    }
