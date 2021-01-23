     /// <summary>
     /// Handles internal token storage, bypassing filesystem
     /// </summary>
    internal class GDriveMemoryDataStore : IDataStore
     {
         private Dictionary<string, TokenResponse> _store;
         private Dictionary<string, string> _stringStore;
         //private key password: notasecret
  
         public GDriveMemoryDataStore()
         {
             _store = new Dictionary<string, TokenResponse>();
             _stringStore = new Dictionary<string, string>();
         }
         public GDriveMemoryDataStore(string key, string refreshToken)
         {
             if (string.IsNullOrEmpty(key))
                 throw new ArgumentNullException("key");
             if (string.IsNullOrEmpty(refreshToken))
                 throw new ArgumentNullException("refreshToken");
  
             _store = new Dictionary<string, TokenResponse>();
             // add new entry
             StoreAsync<TokenResponse>(key,
                 new TokenResponse() { RefreshToken = refreshToken, TokenType = "Bearer" }).Wait();
         }
  
         /// <summary>
         /// Remove all items
         /// </summary>
         /// <returns></returns>
         public async Task ClearAsync()
         {
             await Task.Run(() =>
             {
                 _store.Clear();
                 _stringStore.Clear();
             });
         }
  
         /// <summary>
         /// Remove single entry
         /// </summary>
         /// <typeparam name="T"></typeparam>
         /// <param name="key"></param>
         /// <returns></returns>
         public async Task DeleteAsync<T>(string key)
         {
             await Task.Run(() =>
             {
                // check type
                 AssertCorrectType<T>();
                 if (typeof(T) == typeof(string))
                 {
                     if (_stringStore.ContainsKey(key))
                         _stringStore.Remove(key);                 
                 }
                 else if (_store.ContainsKey(key))
                 {
                     _store.Remove(key);
                 }
             });
         }
  
         /// <summary>
         /// Obtain object
         /// </summary>
         /// <typeparam name="T"></typeparam>
         /// <param name="key"></param>
         /// <returns></returns>
         public async Task<T> GetAsync<T>(string key)
         {
             // check type
             AssertCorrectType<T>();
             if (typeof(T) == typeof(string))
             {
                 if (_stringStore.ContainsKey(key))
                     return await Task.Run(() => { return (T)(object)_stringStore[key]; });
             }
             else if (_store.ContainsKey(key))
             {
                 return await Task.Run(() => { return (T)(object)_store[key]; });
             }
             // key not found
             return default(T);
         }
  
         /// <summary>
         /// Add/update value for key/value
         /// </summary>
         /// <typeparam name="T"></typeparam>
         /// <param name="key"></param>
         /// <param name="value"></param>
         /// <returns></returns>
         public Task StoreAsync<T>(string key, T value)
         {
             return Task.Run(() =>
             {
                 if (typeof(T) == typeof(string))
                 {
                     if (_stringStore.ContainsKey(key))
                         _stringStore[key] = (string)(object)value;
                     else
                         _stringStore.Add(key, (string)(object)value);
                 } else
                 {
                     if (_store.ContainsKey(key))
                         _store[key] = (TokenResponse)(object)value;
                     else
                         _store.Add(key, (TokenResponse)(object)value);
                 }
             });
         }
  
         /// <summary>
         /// Validate we can store this type
         /// </summary>
         /// <typeparam name="T"></typeparam>
         private void AssertCorrectType<T>()
         {
             if (typeof(T) != typeof(TokenResponse) && typeof(T) != typeof(string)) 
                 throw new NotImplementedException(typeof(T).ToString());
         }
     }
