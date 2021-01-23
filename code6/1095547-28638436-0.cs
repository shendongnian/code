	struct Entry
	{
		public string	text;
		public int		rank;
		public Entry( string text, int rank )
		{
			this.text	= text;
			this.rank	= rank;
		}
	}
	List<Entry> ls = new List<Entry>();
	
	...
	void RankInsert( string text, int rank, int indexPrev )
	{
		int insertAt = -1;
		for( int i = 0; i < this.Items.Count; i++ )
		{
			if( rank > ls[ i ].rank
				|| ( rank == ls[ i ].rank
					 && string.CompareOrdinal( text, ls[ i ].text ) < 0 ) )
			{
				insertAt = i;
				break;
			}
		}
		if( indexPrev != -1 )
		{
			ls.RemoveAt( indexPrev );
			listbox.Items.RemoveAt( indexPrev );
		}
		insertAt = ( insertAt != -1 ) ? insertAt : ls.Count;
		ls.Insert( insertAt, new Entry( text, rank ) );
		listbox.Items.Insert( insertAt, text );
	}
