        public static Boolean PathIncludes(String path, String pathToInclude) {
          if (String.IsNullOrEmpty(pathToInclude))
            return false;
          else if (String.IsNullOrEmpty(path))
            return false;
    
          String[] parts = Path.GetFullPath(path).Split(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar, Path.VolumeSeparatorChar);
          String[] partsToInclude = Path.GetFullPath(pathToInclude).Split(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar, Path.VolumeSeparatorChar);
    
          if (parts.Length < partsToInclude.Length)
            return false;
    
          for (int i = 0; i < partsToInclude.Length; ++i)
            if (!String.Equals(parts[i], partsToInclude[i], StringComparison.OrdinalIgnoreCase))
              return false;
    
          return true;
        }
    
        public static Boolean InProgramFiles(String path) {
          return PathIncludes(path, Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86))); 
        }
    
