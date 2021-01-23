	public abstract class DocBase {
		...
		public abstract void LoadProperties(IRepositoryRow row);
		...
	}
	
	public List<T> GetDocs(){    
		var results = someService.GetMyDocuments();
		var documents = new List<T>();
		foreach(IRepositoryRow row in results) {
			var newDoc = new T();
			newDoc.LoadProperties(row);
			documents.Add(newDoc);    
		}
		return documents;
	}
