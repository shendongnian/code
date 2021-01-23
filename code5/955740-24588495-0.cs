    public class Book : VerseSpan
    {
        public static async Task<Book> CreateInstance()
        {
            _Instance = new Book();
    
            await VerseCollection.LoadData(await DigitalQuranDirectories.Data.GetFileAsync("quran-uthmani.bin"));
            await PrivateStorage.LoadQuranObjectsFromMetadata();
            // Some Other Operations too
    
            return _Instance;
        }
    }
    
    
    public class VerseCollection
    {
        static Verse[] _Verses = new Verse[TotalVerses];
    
        internal static async Task LoadData(StorageFile file)
        {
            using (var reader = new BinaryReader(await file.OpenStreamForReadAsync()))
            {
                int wId = 0;
                for (int i = 0; i < VerseCollection.TotalVerses; i++)
                {
                    var retValue = new string[reader.ReadInt32()];
                    for (int j = 0; j < retValue.Length; j++)
                        retValue[j] = reader.ReadString();
    
                    _Verses[i] = new Verse(i, wId, retValue);
    
                    wId += _Verses[i].Words.Count;
                }
            }
        }
    }
    
    public class PrivateStorage
    {
        internal static async Task LoadQuranObjectsFromMetadata()
        {            
            using (var reader = new BinaryReader(await (await DigitalQuranDirectories.Data.GetFileAsync(".metadata")).OpenStreamForReadAsync()))
            {
                /* Some tasks */
            }
        }
    }
