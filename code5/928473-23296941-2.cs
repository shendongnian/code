    ///<summary>Replaces the static methods of System.IO.File
    ///</summary>
    public class FileSystem : IFileSystem
    {
        ///<summary>Creates a new file, writes the specified string to the file, then closes the file. If the file already exists, it is overwritten.
        ///</summary>
        ///<param name="path">The file to write to</param>
        ///<param name="contents">The string to write to the file</param>
        public void WriteAllText(string path, string contents)
        {
            File.WriteAllText(path, contents);
        }
        ///<summary>Creates a new file, writes the specified string to the file, then closes the file. If the file already exists, it is overwritten.
        ///</summary>
        ///<param name="path">The file to write to</param>
        ///<param name="contents">The string to write to the file</param>
        ///<param name="encoding">An <see cref="Encoding"/> object that represents the encoding to apply to the string</param>
        public void WriteAllText(string path, string contents, Encoding encoding)
        {
            File.WriteAllText(path, contents, encoding);
        }
    }
