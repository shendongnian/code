        private TagLib.File GetTags()
        {
            List<string> validAudioFiles = new List<string>() {
                "aac",
                "aif",
                "ape",
                "wma",
                "aa",
                "aax",
                "flac",
                "mka",
                "mpc",
                "mp+",
                "mpp",
                "mp4",
                "m4a",
                "ogg",
                "oga",
                "wav",
                "wv",
                "mp3",
                "m2a",
                "mp2",
                "mp1"
            };
            TagLib.File file = null;
            string ext = Path.GetExtension(this.FilePath);
            if (!string.IsNullOrEmpty(ext))
            {
                ext = ext.Substring(1).ToLower();
                if (validAudioFiles.Contains(ext))
                {
                    try
                    {
                        TagLib.File.LocalFileAbstraction abstraction = new TagLib.File.LocalFileAbstraction(this.FilePath);
                        TagLib.ReadStyle propertiesStyle = TagLib.ReadStyle.Average;
                        switch (ext)
                        {
                            case "aac":
                                {
                                    file = new TagLib.Aac.File(abstraction, propertiesStyle);
                                    break;
                                }
                            case "aif":
                                {
                                    file = new TagLib.Aiff.File(abstraction, propertiesStyle);
                                    break;
                                }
                            case "ape":
                                {
                                    file = new TagLib.Ape.File(abstraction, propertiesStyle);
                                    break;
                                }
                            case "wma":
                                {
                                    file = new TagLib.Asf.File(abstraction, propertiesStyle);
                                    break;
                                }
                            case "aa":
                            case "aax":
                                {
                                    file = new TagLib.Audible.File(abstraction, propertiesStyle);
                                    break;
                                }
                            case "flac":
                                {
                                    file = new TagLib.Flac.File(abstraction, propertiesStyle);
                                    break;
                                }
                            case "mka":
                                {
                                    file = new TagLib.Matroska.File(abstraction, propertiesStyle);
                                    break;
                                }
                            case "mpc":
                            case "mp+":
                            case "mpp":
                                {
                                    file = new TagLib.MusePack.File(abstraction, propertiesStyle);
                                    break;
                                }
                            case "mp4":
                            case "m4a":
                                {
                                    file = new TagLib.Mpeg4.File(abstraction, propertiesStyle);
                                    break;
                                }
                            case "ogg":
                            case "oga":
                                {
                                    file = new TagLib.Ogg.File(abstraction, propertiesStyle);
                                    break;
                                }
                            case "wav":
                                {
                                    file = new TagLib.Riff.File(abstraction, propertiesStyle);
                                    break;
                                }
                            case "wv":
                                {
                                    file = new TagLib.WavPack.File(abstraction, propertiesStyle);
                                    break;
                                }
                            case "mp3":
                            case "m2a":
                            case "mp2":
                            case "mp1":
                                {
                                    file = new TagLib.Mpeg.AudioFile(abstraction, propertiesStyle);
                                    break;
                                }
                        }
                        if (file != null)
                            this._hasAudioTags = true;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("The following exception occurred: " + ex.Message);
                    }
                }
            }
            return file;
        }
