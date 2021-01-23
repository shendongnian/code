          var targetFiles = Directory.GetFiles(targetDir, "*", SearchOption.AllDirectories);
          var notExists = targetFiles.Where(p => !File.Exists(p.Replace(targetDir, sourceDir))).ToList();
    
          foreach (var p in notExists) {
                    try {
                        File.Delete(p);
                    }
                    catch (Exception) {
    
                    }
          }
