			if(mimetype == null) {
				string ext = String.Empty;
				
				int index = abstraction.Name.LastIndexOf (".") + 1;
				
				if(index >= 1 && index < abstraction.Name.Length)
					ext = abstraction.Name.Substring (index,
						abstraction.Name.Length - index);
				
				mimetype = "taglib/" + ext.ToLower(
					CultureInfo.InvariantCulture);
			}
			
			foreach (FileTypeResolver resolver in file_type_resolvers) {
				File file = resolver(abstraction, mimetype,
					propertiesStyle);
				
				if(file != null)
					return file;
			}
			
			if (!FileTypes.AvailableTypes.ContainsKey(mimetype))
				throw new UnsupportedFormatException (
					String.Format (
						CultureInfo.InvariantCulture,
						"{0} ({1})",
						abstraction.Name,
						mimetype));
			
			Type file_type = FileTypes.AvailableTypes[mimetype];
            try
            {
                // This caused the previous try-catch block(s) to be ignored by the Visual Studio debugger
                File file = (File)Activator.CreateInstance(
                    file_type,
                    new object[] { abstraction, propertiesStyle });
                file.MimeType = mimetype;
                return file;
            } catch (System.Reflection.TargetInvocationException e) {
                throw e.InnerException;
            }
		}
