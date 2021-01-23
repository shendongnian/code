    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace UploadToS3Demo
    {
        class Program
        {
            static void Main(string[] args)
            {
                // preparing our file and directory names
                string fileToBackup = @"d:\mybackupFile.zip" ; // test file
                string myBucketName = "mys3bucketname"; //your s3 bucket name goes here
                string s3DirectoryName = "justdemodirectory";
                string s3FileName = @"mybackupFile uploaded in 12-9-2014.zip";
                AmazonUploader myUploader = new AmazonUploader();
                myUploader.sendMyFileToS3(fileToBackup, myBucketName, s3DirectoryName, s3FileName);
            }
        }
    }
