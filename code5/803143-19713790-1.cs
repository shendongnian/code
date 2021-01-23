    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using VersionOne.SDK.APIClient; 
    
    namespace SampleAttachment
    {
    
        class Program
        {
    
            private static readonly string ApplicationURL = "https://myversionone/";
    
            private static readonly string _username = "username";
    
            private static readonly string _password = "passwerd";
    
            private static readonly bool _integrated = false;
    
    
    
            static void Main(string[] args)
            {
    
                //string file = args[0];
                string file = @"C:\Users\MIRVIN\Desktop\Training Wheels\SampleAttachment\bin\Debug\testfile.rtf";
                
                if (File.Exists(file))
                {
    
                    Console.WriteLine("Uploading {0}", file);
                    string mimeType = MimeType.Resolve(file);
    
                    IMetaModel metaModel = new MetaModel(new V1APIConnector(ApplicationURL + "meta.v1/"));
                    IServices services = new Services(metaModel, new V1APIConnector(ApplicationURL + "rest-1.v1/", _username, _password, _integrated));
                    IAttachments attachments = new Attachments(new V1APIConnector(ApplicationURL + "attachment.img/", _username, _password, _integrated));
    
    
                    //cleanjeans scope
                    Oid attachmentContext = Oid.FromToken("Scope:5067", metaModel);
    
    
    
                    IAssetType attachmentType = metaModel.GetAssetType("Attachment");
    
                    IAttributeDefinition attachmentNameDef = attachmentType.GetAttributeDefinition("Name");
    
                    IAttributeDefinition attachmentContentDef = attachmentType.GetAttributeDefinition("Content");
    
                    IAttributeDefinition attachmentContentTypeDef = attachmentType.GetAttributeDefinition("ContentType");
    
                    IAttributeDefinition attachmentFileNameDef = attachmentType.GetAttributeDefinition("Filename");
    
    
    
                    Asset newAttachment = services.New(attachmentType, attachmentContext);
    
                    newAttachment.SetAttributeValue(attachmentNameDef, "New Attachment");
    
                    newAttachment.SetAttributeValue(attachmentContentDef, string.Empty);
    
                    newAttachment.SetAttributeValue(attachmentContentTypeDef, mimeType);
    
                    newAttachment.SetAttributeValue(attachmentFileNameDef, file);
    
                    services.Save(newAttachment);
    
                    //Setup and attach the payload
    
                    string attachmentKey = newAttachment.Oid.Key.ToString();
                    int buffersize = 4096;
    
                    using (FileStream input = new FileStream(file, FileMode.Open, FileAccess.Read))
                    {
    
                        using (Stream output = attachments.GetWriteStream(attachmentKey))
                        {
    
                            byte[] buffer = new byte[buffersize];
    
                            for (; ; )
                            {
    
                                int read = input.Read(buffer, 0, buffersize);
    
                                if (read == 0)
    
                                    break;
    
                                output.Write(buffer, 0, read);
    
                            }
    
                        }
    
                    }
    
                    attachments.SetWriteStream(attachmentKey, mimeType);
    
    
    
                    Console.WriteLine("{0} uploaded", file);
    
                }
    
                else
    
                    Console.WriteLine("{0} does not exist", file);
    
            }
    
        }
    
            }
