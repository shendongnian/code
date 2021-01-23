    Mapper.CreateMap<Assay,AssayDto>()
          .ForMember(dto => 
                dto.Genes, 
                m => m.MapFrom(a => GenesList // your separate list of genes
                                    .Where(g => g.AssayID == a.AssayID)
                                    .Select(g => g.Name)));
