    using System.Security.Cryptography;
    private void compare_btn_Click(object sender, EventArgs e)
    {
    	string firstFile = firstExcel_txt.Text;
    	ExcelInfo file1 = ReadExcel(openFileDialog1);
    	
    	string secondFile = secondExcel_txt.Text;
    	ExcelInfo file2 = ReadExcel(openFileDialog2);
    	
    	CompareExcels(file1,file2) ;
    }    
	
	public void CompareExcels(ExcelInfo fileA, ExcelInfo fileB)
	{
		foreach(ExcelRow rowA in fileA.excelRows)
		{
			//If the current hash of a row of fileA does not exists in fileB then it was removed 
			if(! fileB.ContainsHash(rowA.hash))
			{
				Console.WriteLine("Row removed" + rowA.ToString());
			}
		}
		
		foreach(ExcelRow rowB in fileB.excelRows)
		{
			//If the current hash of a row of fileB does not exists in fileA then it was added 
			if(! fileA.ContainsHash(rowB.hash))
			{
				Console.WriteLine("Row added" + rowB.ToString());
			}
		}
	}
	
    public Class ExcelRow
    {
    	public List<String> lstCells ;
        public byte[] hash
    	
		public ExcelRow()
		{
			lstCells = new List<String>() ;
		}
		public override string ToString()
        {
			string resp ;
			
			resp = string.Empty ;
			
			foreach(string cellText in lstCells)
			{
				if(resp != string.Empty)
				{
					resp = resp + "," + cellText ;
				}
				else
				{
					resp = cellText ;
				}	
			}
			return resp ;
        }		
    	public void CalculateHash()
    	{
    		byte[] rowBytes ;
    		byte[] cellBytes ;
    		int pos ;
    		int numRowBytes ;
    
    		//Determine how much bytes are required to store a single excel row
    		numRowBytes = 0 ;
    		foreach(string cellText in lstCells)
    		{
    			numRowBytes += NumBytes(cellText) ;
    		}		
    		
    		//Allocate space to calculate the HASH of a single row
    		
    		rowBytes= new byte[numRowBytes]
    		pos = 0 ;
    		
    		//Concatenate the cellText of each cell, converted to bytes,into a single byte array
    		foreach(string cellText in lstCells)
    		{
    			cellBytes = GetBytes(cellText) ;
    			System.Buffer.BlockCopy(cellBytes, 0, rowBytes, pos, cellBytes.Length);
    			pos = cellBytes.Length ;
    			
    		}
    		
    		hash = new MD5CryptoServiceProvider().ComputeHash(rowBytes);
    		
    	}
    	static int NumBytes(string str)
    	{
    		return str.Length * sizeof(char);
    	}
    	
    	static byte[] GetBytes(string str)
    	{
    		byte[] bytes = new byte[NumBytes(str)];
    		System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
    		return bytes;
    	}
    }
    public Class ExcelInfo
    {
     	public List<ExcelRow> excelRows ;
		
		public ExcelInfo()
		{
			excelRows = new List<ExcelRow>();
		}
		public bool ContainsHash(byte[] hashToLook)
		{
			bool found ;
			
			found = false ;
			
			foreach(ExcelRow eRow in excelRows)
			{
				found = EqualHash(eRow.hash, hashToLook) ;
				
				if(found)
				{
					break ;
				}
			}
			
			return found ;
		}
		public static EqualHash(byte[] hashA, byte[] hashB)
		{
			bool bEqual ;
			int i ;
			
			bEqual	= false;
			if (hashA.Length == hashB.Length)
			{
				i = 0;
				while ((i < hashA.Length) && (hashA[i] == hashB[i]))
				{
					i++ ;
				}
				if (i == hashA.Length)
				{
					bEqual = true;
				}
			}
			return bEqual ;
		}
    }
    
    public ExcelInfo ReadExcel(OpenFileDialog openFileDialog)
    {
    	var _excelFile = new ExcelQueryFactory(openFileDialog.FileName);
    	var _info = from c in _excelFile.WorksheetNoHeader() select c;
    
    	ExcelRow excelRow ;
    	ExcelInfo resp ;
    
    	resp = new ExcelInfo() ;
    
    	foreach (var item in _info)
    	{
    		excelRow = new ExcelRow() ;
			
			//Add all the cells (with a for each)
    		excelRow.lstCells.Add(item.ElementAt(0));
    		excelRow.lstCells.Add(item.ElementAt(1));
    		....
    		//Add the last cell of the row
    		excelRow.lstCells.Add(item.ElementAt(N));
			
			//Calculate the hash of the row
    		excelRow.CalculateHash() ;
			
			//Add the row to the ExcelInfo object
    		resp.excelRows.Add(excelRow) ;
    	}
    	return resp ;
    }
    
    
