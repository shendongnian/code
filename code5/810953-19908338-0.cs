    <Association Name="FK_Table1ID">
              <End Role="Table1" Type="XOneModel.Store.Table1" Multiplicity="1" />
              <End Role="Table2" Type="XOneModel.Store.Table2" Multiplicity="0..1" />
              <ReferentialConstraint>
                <Principal Role="Table1">
                  <PropertyRef Name="id" />
                </Principal>
                <Dependent Role="Table2">
                  <PropertyRef Name="Table1Id" />
                </Dependent>
              </ReferentialConstraint>
            </Association>
