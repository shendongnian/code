            /// <summary>
        /// Stop recording and play it back
        /// </summary>
        private async void StopCapture()
        {
            Debug.WriteLine("Stopping recording");
 	        await _mediaCaptureManager.StopRecordAsync();
            Debug.WriteLine("Stop recording successful");
            var stream = await _recordStorageFile.OpenAsync(FileAccessMode.Read);
            Debug.WriteLine("Recording file opened");
            playbackElement1.AutoPlay = true;
            playbackElement1.SetSource(stream, _recordStorageFile.FileType);
            playbackElement1.Play();
        }
