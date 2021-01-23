	public partial class Artysta
		{
			public Artysci()
			{
				this.SpektaklArtysta = new HashSet<SpektaklArtysta>();
			}
		[Key]
		public int ArtystaID { get; set; }
		public string Imie { get; set; }
		public string Nazwisko { get; set; }      
		public List<Artysta> Artysci = ArtistRepository.GetAllArtists();
	}
