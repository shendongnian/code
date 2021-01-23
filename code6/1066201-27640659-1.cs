    private void DisposeBarcodeReaderAndData()
    {
        ExceptionLoggingService.Instance.WriteLog("Reached frmDelivery.DisposeBarcodeReaderAndData");
        // Commenting out to see if this prevents the NRE; if so, try moving this to FromClose or FormClosing or something similar
        //// If we have a reader
        //if (this.barcodeReader != null)
        //{
        //    // Disable the reader
        //    this.barcodeReader.Actions.Disable();
        //    // Free it up
        //    this.barcodeReader.Dispose();
        //    // Indicate we no longer have one
        //    this.barcodeReader = null;
        //}
        //// If we have a reader data
        //if (this.barcodeReaderData != null)
        //{
        //    // Free it up
        //    this.barcodeReaderData.Dispose();
        //    // Indicate we no longer have one
        //    this.barcodeReaderData = null;
        //}
    }
