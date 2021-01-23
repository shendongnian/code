    string mediafile = "asaqwrereertrtyrzxxcvcvvbvbv+qwwezzxzxz";
     byte[] PlayByte = Convert.FromBase64String(mediafile);
            MemoryStream stream = new MemoryStream(PlayByte, 0, PlayByte.Length);
            string finalstring = stream.ToString();
            **MediaElement1.Source = null;**
                IsolatedStorageFileStream isfStream = new IsolatedStorageFileStream(audioName, FileMode.Create, IsolatedStorageFile.GetUserStoreForApplication());
                isfStream.Write(stream.ToArray(), 0, stream.ToArray().Length);
                isfStream.Close();
                Uri uri = new Uri(isfStream.Name.ToString());
                MediaElement1.Source = uri;
                MediaElement1.Play();
