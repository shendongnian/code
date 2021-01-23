       JobInfo = m_bigQueryService.Jobs.Insert(jobBody, sProject, file, "application/octet-stream");
                    // Chunk size in MB
                    JobInfo.ChunkSize = 1 * Google.Apis.Upload.ResumableUpload<Job>.MinimumChunkSize; // currently 250kb
                    int t = 1;
                    JobInfo.ProgressChanged += progress =>
                        {
                            // You can put what ever you like here - triggered after each chunk is uploaded
                        };
                    
                    uploadProgress = JobInfo.Upload(); // Sync upload
                    
                    
                    if (uploadProgress.Status != UploadStatus.Completed)
                    {
                        // Do something
                    }
