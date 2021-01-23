    //Modulo1
                    List<string> aux1 = new List<string>();
                    for (int i = 0; i < fechasMaterias1.Count; i+=4)
                    {
                        aux1.Add(fechasMaterias1.ElementAt(i));
                    }
                    List<string> aux2 = new List<string>();
                    for (int i = 0; i < fechasMaterias2.Count; i += 4)
                    {
                        aux2.Add(fechasMaterias2.ElementAt(i));
                    }
                    List<string> aux3 = new List<string>();
                    for (int i = 0; i < fechasMaterias3.Count; i += 4)
                    {
                        aux3.Add(fechasMaterias3.ElementAt(i));
                    }
                    fechasMaterias1 = aux1;
                    fechasMaterias2 = aux2;
                    fechasMaterias3 = aux3;
                    if (Modulo1.Count > 0)
                    {
                        string dia = String.Empty;
                        foreach (List<DateTime> item in diasMaterias1)
                        {
                            for (int i = 0; i < item.Count; i++)
                            {
                                if (i == 0)
                                    dia += "Horario del " + item.ElementAt(i).ToString("d \\de MMMM", culture) + " al ";
                                else
                                    dia += item.ElementAt(i).ToString("d \\de MMMM", culture);
                                
                            }
                            
                        }
                        dias1.Add(dia);
                        Modulo1.ForEach(t => view_result1.Add(new HorariosModulosViewModel
                        {
                            NombreMateria = t.Nombre,
                            ModuloNum = "Módulo " + NumerosModulos.Where(x => x.Equals(1)).FirstOrDefault().ToString(),
                            NombreModulo = ModulosNombre[0],
                            Grupo = t.Grupo.ToString(),
                            IdMateriasCursos = t.IdMateriasCursos
                            
                        }));
                        for (int i = 0; i < dias1.Count; i++)
                        {
                            view_result1.ElementAt(i).dias = dias1.FirstOrDefault();
                        }
                        view_result1.ForEach(t => t.diasMateria = fechasMaterias1);
                        var materiasListado1 = Modulo1.GroupBy(t=> t.IdMateriasCursos).ToList();
                        foreach(var item in materiasListado1) {
                        horariosMaterias1.Add(new Dictionary<int, string>() {{item.Key, (from U in item where U.IdMateriasCursos.Equals(item.Key) select U.HorarioInicio.ToString("hh\\:mm")+" a "+U.HorarioFin.ToString("hh\\:mm")).First()}});
                        }
                        view_result1.ForEach(t => t.horarios = horariosMaterias1.Where(p=> p.Keys.Contains(t.IdMateriasCursos)).ToList());
                        var maestrosListado1 = maestros1.GroupBy(t=> t.IdMateriasCursos).ToList();
                    
                    foreach(var item in maestrosListado1)
                    {
                        losMaestros1.Add(item.Key, (from U in item where U.IdMateriasCursos.Equals(item.Key) select String.Join(" ", U.Titulo, U.Nombres, U.ApellidoPaterno, U.ApellidoMaterno)).ToList());
                    }
                    view_result1.ForEach(t => t.Maestros = losMaestros1.Where(x=> x.Key.Equals(t.IdMateriasCursos)).ToDictionary(r=> r.Key, v=> v.Value));
                    }
