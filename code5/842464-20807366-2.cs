    <Edmx Version='3.0' xmlns='http://schemas.microsoft.com/ado/2009/11/edmx'>
      <Runtime>
        <ConceptualModels>
        ...
        </ConceptualModels>
        <Mappings>
          <Mapping Space='C-S' xmlns='http://schemas.microsoft.com/ado/2009/11/mapping/cs'>
            <EntityContainerMapping StorageEntityContainer='CodeFirstDatabase' CdmEntityContainer='UserQuery'>
              <EntitySetMapping Name='Categories'>
                <EntityTypeMapping TypeName='CodeFirstNamespace.Category'>
                  <MappingFragment StoreEntitySet='Category'>
                    <ScalarProperty Name='CategoryID' ColumnName='CategoryID' />
                    ...
                  </MappingFragment>
                </EntityTypeMapping>
              </EntitySetMapping>
              <AssociationSetMapping Name='Category_Products' TypeName='CodeFirstNamespace.Category_Products' StoreEntitySet='CategoryProduct'>
              </AssociationSetMapping>
            </EntityContainerMapping>
          </Mapping>
        </Mappings>
        <StorageModels>
        ...
        </StorageModels>
      </Runtime>
      <Designer>
      ...
      </Designer>
    </Edmx>
