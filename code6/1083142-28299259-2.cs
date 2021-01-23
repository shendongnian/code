        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            mediaScanIntent.SetData(Uri.FromFile(file));
            SendBroadcast(mediaScanIntent);
            App.Instance.ShowImage(file.Path);
        }
