            public static async Task<string> UploadFile<T>( string skydriveFolderId,
                                                        T objectToSerialize,
                                                        string fileNameInSkyDrive )
            {
            string fileID = string.Empty;
            using ( var memoryStream = new MemoryStream() )
                {
                try
                    {
                    var serializer = new DataContractJsonSerializer( objectToSerialize.GetType() );
                    serializer.WriteObject( memoryStream, objectToSerialize );
                    memoryStream.Seek( 0, SeekOrigin.Begin );
                    LiveOperationResult liveOpResult = await Client.UploadAsync( skydriveFolderId, fileNameInSkyDrive, memoryStream, OverwriteOption.Overwrite );
                    fileID = (string)liveOpResult.Result [ "id" ];
                    Debug.WriteLine( "\nUploadFile: " + fileNameInSkyDrive );
                    }
                catch ( Exception e )
                    {
                    MessageBox.Show( e.Message, "Upload Error", MessageBoxButton.OK );
                    Debug.WriteLine( "\nError - UploadFile: " + e.Message );
                    }
                }
            return fileID;
            }
