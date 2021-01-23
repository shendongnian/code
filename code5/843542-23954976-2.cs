        #region IDisposable Members
        /// <summary>
        /// Cancels any pending transfer and frees resources.
        /// </summary>
        public virtual void Dispose()
        {
            if (!IsCancelled) Cancel();
            //I just commented here.
            //int dummy; 
            //if (!mHasWaitBeenCalled) Wait(out dummy);
            if (mPinnedHandle != null) mPinnedHandle.Dispose();
            mPinnedHandle = null;
        }
        #endregion
        ~UsbTransfer() { Dispose(); }
