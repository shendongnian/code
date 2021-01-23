     var username = usuario.SelectSingleNode("username").InnerText;
     var nombre = usuario.SelectSingleNode("nombre").InnerText;
     var fechaNacimiento = usuario.SelectSingleNode("fechaNacimiento").InnerText 
     var nickName = usuario.SelectSingleNode("nickname").InnerText;
     rg = new Registrado(
                        username,
                        "NA",
                        nombre,
                        DateTime.ParseExact(fechaNacimiento, "dd-MM-yyyy HH:mm:ss", null),
                        nickName,
                        null,
                        null,
                        null,
                        null,
                        true
                        );
