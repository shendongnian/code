    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    
    using Google.Apis.Util.Store;
    using Google.Apis.Json;
    
    namespace Google.Apis.Util.Store {
        public class AppDataFileStore : IDataStore {
            readonly string folderPath;
            /// <summary>Gets the full folder path.</summary>
            public string FolderPath { get { return folderPath; } }
    
            /// <summary>
            /// Constructs a new file data store with the specified folder. This folder is created (if it doesn't exist
            /// yet) under <see cref="Environment.SpecialFolder.ApplicationData"/>.
            /// </summary>
            /// <param name="folder">Folder name.</param>
            public AppDataFileStore(string folder) {
                folderPath = Path.Combine(HttpContext.Current.Server.MapPath("~/App_Data/"), folder);
                if (!Directory.Exists(folderPath)) {
                    Directory.CreateDirectory(folderPath);
                }
            }
    
            /// <summary>
            /// Stores the given value for the given key. It creates a new file (named <see cref="GenerateStoredKey"/>) in
            /// <see cref="FolderPath"/>.
            /// </summary>
            /// <typeparam name="T">The type to store in the data store.</typeparam>
            /// <param name="key">The key.</param>
            /// <param name="value">The value to store in the data store.</param>
            public Task StoreAsync<T>(string key, T value) {
                if (string.IsNullOrEmpty(key)) {
                    throw new ArgumentException("Key MUST have a value");
                }
    
                var serialized = NewtonsoftJsonSerializer.Instance.Serialize(value);
                var filePath = Path.Combine(folderPath, GenerateStoredKey(key, typeof(T)));
                File.WriteAllText(filePath, serialized);
                return TaskEx.Delay(0);
            }
    
            /// <summary>
            /// Deletes the given key. It deletes the <see cref="GenerateStoredKey"/> named file in
            /// <see cref="FolderPath"/>.
            /// </summary>
            /// <param name="key">The key to delete from the data store.</param>
            public Task DeleteAsync<T>(string key) {
                if (string.IsNullOrEmpty(key)) {
                    throw new ArgumentException("Key MUST have a value");
                }
    
                var filePath = Path.Combine(folderPath, GenerateStoredKey(key, typeof(T)));
                if (File.Exists(filePath)) {
                    File.Delete(filePath);
                }
                return TaskEx.Delay(0);
            }
    
            /// <summary>
            /// Returns the stored value for the given key or <c>null</c> if the matching file (<see cref="GenerateStoredKey"/>
            /// in <see cref="FolderPath"/> doesn't exist.
            /// </summary>
            /// <typeparam name="T">The type to retrieve.</typeparam>
            /// <param name="key">The key to retrieve from the data store.</param>
            /// <returns>The stored object.</returns>
            public Task<T> GetAsync<T>(string key) {
                if (string.IsNullOrEmpty(key)) {
                    throw new ArgumentException("Key MUST have a value");
                }
    
                TaskCompletionSource<T> tcs = new TaskCompletionSource<T>();
                var filePath = Path.Combine(folderPath, GenerateStoredKey(key, typeof(T)));
                if (File.Exists(filePath)) {
                    try {
                        var obj = File.ReadAllText(filePath);
                        tcs.SetResult(NewtonsoftJsonSerializer.Instance.Deserialize<T>(obj));
                    }
                    catch (Exception ex) {
                        tcs.SetException(ex);
                    }
                }
                else {
                    tcs.SetResult(default(T));
                }
                return tcs.Task;
            }
    
            /// <summary>
            /// Clears all values in the data store. This method deletes all files in <see cref="FolderPath"/>.
            /// </summary>
            public Task ClearAsync() {
                if (Directory.Exists(folderPath)) {
                    Directory.Delete(folderPath, true);
                    Directory.CreateDirectory(folderPath);
                }
    
                return TaskEx.Delay(0);
            }
    
            /// <summary>Creates a unique stored key based on the key and the class type.</summary>
            /// <param name="key">The object key.</param>
            /// <param name="t">The type to store or retrieve.</param>
            public static string GenerateStoredKey(string key, Type t) {
                return string.Format("{0}-{1}", t.FullName, key);
            }
        }
    }
