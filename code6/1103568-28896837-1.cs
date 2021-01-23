    <VSTemplate Version="3.0.0" Type="ProjectGroup"
        xmlns="http://schemas.microsoft.com/developer/vstemplate/2005">
      <TemplateData>
        <Name>My Template</Name>
        <Description>Solution template</Description>
        <Icon>Icon.png</Icon>
        <ProjectType>CSharp</ProjectType>
      </TemplateData>
      <TemplateContent>
        <ProjectCollection>
          <ProjectTemplateLink ProjectName="$safeprojectname$.DataModel">
            APP.DataModel\ProjectTemplate.vstemplate
          </ProjectTemplateLink>
        </ProjectCollection>
      </TemplateContent>
      <WizardExtension>
        <Assembly>Wizard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=97aaf9683a0dbe2b</Assembly>
        <FullClassName>Wizard.Wizard</FullClassName>
      </WizardExtension>
    </VSTemplate>
