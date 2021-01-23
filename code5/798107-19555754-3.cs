	public partial class MyWcfService: IMySerciceContract, IDisposable {
		private DatabaseOperations _dataAccess;
		public void Dispose() {
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
		protected virtual void Dispose(bool disposing) {
			if(!this.disposed) {
				if(disposing) {
					_dataAccess.Dispose();
				}
				this.disposed=true;
			}
		}
		// so it make sense now .. 
		~MyWcfService() {
			this.Dispose(false);
		}
		bool disposed;
	}
