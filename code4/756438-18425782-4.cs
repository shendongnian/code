    <unity xmlns="http://schemas.microsoft.com/practices/2010/unity">
      <container>
        <register type ="UnityTest.IImageRepositoryService, UnityTest" mapTo="UnityTest.ImageRepositoryService, UnityTest">
          <constructor />
        </register>
        <register name="ParameterizedRepository" 
                  type="UnityTest.IImageRepositoryService, UnityTest" 
                  mapTo="UnityTest.ImageRepositoryService, UnityTest">
          <constructor>
            <param name="filterName" value="dummyValue" />
          </constructor>
        </register>
      </container>
    </unity>
