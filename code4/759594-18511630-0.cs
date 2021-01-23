        public void Clear()
        {
          using (this.TextSelectionInternal.DeclareChangeBlock())
          {
            this.TextContainer.DeleteContentInternal(this.TextContainer.Start, this.TextContainer.End);
            this.TextSelectionInternal.Select(this.TextContainer.Start, this.TextContainer.Start);
          }
        }
